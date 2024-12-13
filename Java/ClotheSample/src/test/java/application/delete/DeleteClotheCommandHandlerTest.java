package application.delete;

import application.results.Result;
import domain.entities.ClotheEntity;
import domain.repositories.IRepository;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Tag;
import org.junit.jupiter.api.Test;
import org.mockito.*;

import javax.validation.ConstraintViolation;
import javax.validation.Validator;
import java.util.Optional;
import java.util.Set;
import java.util.UUID;

import static org.mockito.Mockito.*;
import static org.junit.jupiter.api.Assertions.*;

class DeleteClotheCommandHandlerUnitTest {

    private DeleteClotheCommandHandler handler;
    private IRepository repositoryMock;
    private Validator validatorMock;

    @BeforeEach
    void setUp() {
        // Initialize mock objects
        repositoryMock = mock(IRepository.class);
        validatorMock = mock(Validator.class);

        // Create handler with mocked dependencies
        handler = new DeleteClotheCommandHandler(repositoryMock, validatorMock);
    }

    @Test
    @Tag("Clothe")
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

        // Act
        Result result = handler.handle(request);

        // Assert
        assertTrue(result.isSuccess());
        assertEquals("Clothe deleted successfully", result.getMessage());
        assertEquals(clotheId, result.getData().get());
        verify(repositoryMock, times(1)).delete(clotheEntity);
    }

    @Test
    @Tag("Clothe")
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
    }
}
