package application.create;

import application.results.Result;
import domain.entities.ClotheEntity;
import domain.repositories.IRepository;
import javax.validation.ConstraintViolation;
import javax.validation.ConstraintViolationException;
import javax.validation.Validator;
import org.springframework.stereotype.Service;

import java.util.Set;
import java.util.UUID;

@Service
public class CreateClotheCommandHandler {

    private final Validator validator;
    private final IRepository repository;

    public CreateClotheCommandHandler(Validator validator, IRepository repository) {
        this.validator = validator;
        this.repository = repository;
    }

    public Result handle(CreateClotheCommand request) {
        // Validate the command
        Set<ConstraintViolation<CreateClotheCommand>> violations = validator.validate(request);
        if (!violations.isEmpty()) {
            throw new ConstraintViolationException("Invalid data", violations);
        }

        // Create a new ClotheEntity
        ClotheEntity clothe = new ClotheEntity(
                request.getName(),
                request.getModel(),
                request.getYear(),
                request.getSize(),
                request.getColor()
        );

        // Persist the entity
        repository.save(clothe);


        // Return the result
        return new Result(true, "Clothe created successfully", clothe.getId());
    }
}
