package application.delete;

import application.results.Result;
import domain.entities.ClotheEntity;
import domain.repositories.IRepository;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.*;
import org.springframework.http.ResponseEntity;
import org.springframework.web.client.RestTemplate;

import javax.validation.ConstraintViolation;
import javax.validation.Validator;
import java.util.Optional;
import java.util.Set;
import java.util.UUID;

import static org.mockito.Mockito.*;
import static org.junit.jupiter.api.Assertions.*;

class DeleteClotheCommandHandler2UnitTest {

    private DeleteClotheCommandHandler2 handler;
    private IRepository repositoryMock;
    private RestTemplate restTemplateMock;
    private Validator validatorMock;

    @BeforeEach
    void setUp() {
        // Initialize mock objects
        repositoryMock = mock(IRepository.class);
        restTemplateMock = mock(RestTemplate.class);
        validatorMock = mock(Validator.class);

        // Create handler with mocked dependencies
        handler = new DeleteClotheCommandHandler2(repositoryMock, restTemplateMock, validatorMock);
    }

    @Test
    void handle_ValidRequest_ShouldReturnSuccessResult() {
        // Arrange
        UUID clotheId = UUID.randomUUID();
        DeleteClotheCommand request = new DeleteClotheCommand(clotheId);

        // Create mock ClotheEntity to be returned by the repository
        ClotheEntity clotheEntity = new ClotheEntity("Test", "Cotton", 2024, "M", "Color");
        clotheEntity.setId(clotheId);

        // Mock the validation result (no violations)
        when(validatorMock.validate(request)).thenReturn(Set.of());

        // Mock the repository's findById to return the ClotheEntity
        when(repositoryMock.findById(clotheId)).thenReturn(Optional.of(clotheEntity));

        // Mock the REST API call to return a successful response
        Result apiResult = new Result(true, "Deletion allowed", null);
        ResponseEntity<Result> apiResponse = ResponseEntity.ok(apiResult);
        when(restTemplateMock.getForEntity(DeleteClotheCommandHandler2.API_URL, Result.class)).thenReturn(apiResponse);

        // Act
        Result result = handler.handle(request);

        // Assert
        assertTrue(result.isSuccess());
        assertEquals("Clothe deleted successfully", result.getMessage());
        assertEquals(clotheId, result.getData().get());
        verify(repositoryMock, times(1)).delete(clotheEntity);
    }

    @Test
    void handle_InvalidRequest_ShouldReturnFailureResult() {
        // Arrange
        UUID clotheId = UUID.randomUUID();
        DeleteClotheCommand request = new DeleteClotheCommand(clotheId);

        // Mock the validation result (with violations)
        ConstraintViolation<DeleteClotheCommand> violation = mock(ConstraintViolation.class);
        when(validatorMock.validate(request)).thenReturn(Set.of(violation));

        // Act
        Result result = handler.handle(request);

        // Assert
        assertFalse(result.isSuccess());
        assertEquals("Invalid data", result.getMessage());
        verify(repositoryMock, never()).findById(any());
        verify(restTemplateMock, never()).getForEntity(any(), eq(Result.class));
    }

    @Test
    void handle_ClotheNotFound_ShouldReturnFailureResult() {
        // Arrange
        UUID clotheId = UUID.randomUUID();
        DeleteClotheCommand request = new DeleteClotheCommand(clotheId);

        // Mock the validation result (no violations)
        when(validatorMock.validate(request)).thenReturn(Set.of());

        // Mock the repository's findById to return an empty Optional (not found)
        when(repositoryMock.findById(clotheId)).thenReturn(Optional.empty());

        // Act
        Result result = handler.handle(request);

        // Assert
        assertFalse(result.isSuccess());
        assertEquals("Clothe not found", result.getMessage());
        verify(repositoryMock, never()).delete(any());
        verify(restTemplateMock, never()).getForEntity(any(), eq(Result.class));
    }

    @Test
    void handle_ApiCallFailure_ShouldReturnFailureResult() {
        // Arrange
        UUID clotheId = UUID.randomUUID();
        DeleteClotheCommand request = new DeleteClotheCommand(clotheId);

        // Create mock ClotheEntity to be returned by the repository
        ClotheEntity clotheEntity = new ClotheEntity("Test", "Cotton", 2024, "M", "Color");
        clotheEntity.setId(clotheId);

        // Mock the validation result (no violations)
        when(validatorMock.validate(request)).thenReturn(Set.of());

        // Mock the repository's findById to return the ClotheEntity
        when(repositoryMock.findById(clotheId)).thenReturn(Optional.of(clotheEntity));

        // Mock the REST API call to return a failure response
        ResponseEntity<Result> apiResponse = ResponseEntity.badRequest().build();
        when(restTemplateMock.getForEntity(DeleteClotheCommandHandler2.API_URL, Result.class)).thenReturn(apiResponse);

        // Act
        Result result = handler.handle(request);

        // Assert
        assertFalse(result.isSuccess());
        assertEquals("Failed to call external API", result.getMessage());
        verify(repositoryMock, never()).delete(any());
    }

    @Test
    void handle_InvalidApiResponse_ShouldThrowException() {
        // Arrange
        UUID clotheId = UUID.randomUUID();
        DeleteClotheCommand request = new DeleteClotheCommand(clotheId);

        // Create mock ClotheEntity to be returned by the repository
        ClotheEntity clotheEntity = new ClotheEntity("Test", "Cotton", 2024, "M", "Color");
        clotheEntity.setId(clotheId);

        // Mock the validation result (no violations)
        when(validatorMock.validate(request)).thenReturn(Set.of());

        // Mock the repository's findById to return the ClotheEntity
        when(repositoryMock.findById(clotheId)).thenReturn(Optional.of(clotheEntity));

        // Mock the REST API call to return a valid response, but with null body
        ResponseEntity<Result> apiResponse = ResponseEntity.ok().body(null);
        when(restTemplateMock.getForEntity(DeleteClotheCommandHandler2.API_URL, Result.class)).thenReturn(apiResponse);

        // Act and Assert
        assertThrows(IllegalStateException.class, () -> handler.handle(request));
    }
}
