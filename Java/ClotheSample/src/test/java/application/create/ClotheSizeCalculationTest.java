package application.create;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;
import static org.junit.jupiter.api.Assertions.*;

class ClotheSizeCalculationTest {

    private final ClotheSizeCalculation clotheSizeCalculation = new ClotheSizeCalculation();

    @ParameterizedTest
    @CsvSource({
            "20, 10, S",
            "100, 80, L",
            "50, 40, M",
            "130, 110, XXL"
    })
    void calculate_ShouldBe_OK(int height, int width, String expectedSize) {
        String size = clotheSizeCalculation.calculate(height, width);
        assertEquals(expectedSize, size);
    }

    @Test
    void calculate_ShouldThrowException_WhenInvalidData() {
        // Test for invalid data exception
        IllegalArgumentException exception = assertThrows(IllegalArgumentException.class, () -> {
            clotheSizeCalculation.calculate(0, -1);
        });
        assertEquals("Invalid height or width", exception.getMessage());
    }
}
