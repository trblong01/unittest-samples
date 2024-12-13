package application.create;
public class ClotheSizeCalculation {

    public ClotheSizeCalculation() {
        // Default constructor
    }

    public String calculate(int height, int width) {
        if (height <= 0 || width <= 0) {
            throw new IllegalArgumentException("Invalid height or width");
        }

        if (height <= 40 && width <= 20) {
            return "S";
        }

        if (height >= 80 && height <= 120 && width >= 60 && width <= 100) {
            return "L";
        }

        if (height >= 40 && height < 80 && width >= 20 && width < 60) {
            return "M";
        }

        return "XXL";
    }
}