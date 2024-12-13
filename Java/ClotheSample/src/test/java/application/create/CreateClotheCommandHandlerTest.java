package application.create;

import domain.entities.ClotheEntity;
import domain.repositories.IRepository;
import application.results.Result;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Tag;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;
import org.mockito.*;
import javax.validation.*;
import java.util.Set;

import static org.mockito.Mockito.*;
import static org.junit.jupiter.api.Assertions.*;

class CreateClotheCommandHandlerUnitTest {

    private CreateClotheCommandHandler handler;
    private Validator validatorMock;
    private IRepository repositoryMock;

    @BeforeEach
    void setUp() {
        // Create mock objects for the dependencies
        validatorMock = mock(Validator.class);
        repositoryMock = mock(IRepository.class);

        // Initialize the handler with the mocks
        handler = new CreateClotheCommandHandler(validatorMock, repositoryMock);
    }

    @Test
    void handle_ValidRequest_ShouldReturnSuccessResult() {
        // Arrange
        var request = new CreateClotheCommand("Test", "Cotton", 2024, "XXL", "Color");

        // Mock the validation result (no violations)
        when(validatorMock.validate(request)).thenReturn(Set.of());

        // Mock the repository save method
        ClotheEntity savedClothe = new ClotheEntity("Test", "Cotton", 2024, "XXL", "Color");
        when(repositoryMock.save(any(ClotheEntity.class))).thenReturn(savedClothe);

        // Act
        Result result = handler.handle(request);

        // Assert
        assertTrue(result.isSuccess());
        assertEquals("Clothe created successfully", result.getMessage());
        assertNotNull(result.getData());
    }


    @ParameterizedTest
    @CsvSource({
            "null, Cotton, 2022, S, White",
            "Test, null, 2022, M, Black",
            "Test, Cotton, 2024, L, ''",
            "Test, Jean, 2022, null, Blue",
            "Test, Jean, 2022, '', Red"
    })
    @Tag("Clothe")
    void handle_InvalidRequest_ShouldThrowConstraintViolationException(String name, String model, int year, String size, String color)  {
        // Arrange
        var request = new CreateClotheCommand(name,model,year,size,color);

        // Mock the validation result (with violations)
        ConstraintViolation<CreateClotheCommand> violation = mock(ConstraintViolation.class);
        when(validatorMock.validate(request)).thenReturn(Set.of(violation));

        // Act & Assert
        ConstraintViolationException exception = assertThrows(ConstraintViolationException.class, () -> {
            handler.handle(request);
        });
        assertEquals("Invalid data", exception.getMessage());
    }
}
