package domain.entities;

import javax.persistence.*;
import java.util.UUID;

@Entity
@Table(name = "clothes")
public class ClotheEntity extends BaseEntity {

    @Column(nullable = false)
    private String name;

    @Column(nullable = false)
    private String fabric;

    @Column(nullable = false)
    private int year;

    @Column(nullable = false)
    private String size;

    @Column(nullable = false)
    private String color;

    // No-args constructor (required by JPA)
    protected ClotheEntity() {}

    // All-args constructor
    public ClotheEntity(String name, String fabric, int year, String size, String color) {
        this.name = name;
        this.fabric = fabric;
        this.year = year;
        this.size = size;
        this.color = color;
    }


    // Getters
    public String getName() {
        return name;
    }

    public String getFabric() {
        return fabric;
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
