package application.create;



import javax.validation.constraints.*;

public class CreateClotheCommand {

    @NotEmpty(message = "Name cannot be empty")
    @Size(max = 50, message = "Name must not exceed 50 characters")
    private final String name;

    @NotEmpty(message = "Model cannot be empty")
    @Size(max = 50, message = "Model must not exceed 50 characters")
    private final String model;

    @Min(value = 2024, message = "Year must be 2024 or later")
    private final int year;

    @NotEmpty(message = "Size cannot be empty")
    @Size(max = 5, message = "Size must not exceed 5 characters")
    private final String size;

    @NotEmpty(message = "Color cannot be empty")
    @Size(max = 15, message = "Color must not exceed 15 characters")
    private final String color;

    public CreateClotheCommand(String name, String model, int year, String size, String color) {
        this.name = name;
        this.model = model;
        this.year = year;
        this.size = size;
        this.color = color;
    }

    public String getName() {
        return name;
    }

    public String getModel() {
        return model;
    }

    public int getYear() {
        return year;
    }

    public String getSize() {
        return size;
    }

    public String getColor() {
        return color;
    }
}
