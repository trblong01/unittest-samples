package application.delete;

import application.create.CreateClotheCommand;
import application.results.Result;
import domain.entities.ClotheEntity;
import domain.repositories.IRepository;
import org.springframework.stereotype.Service;

import javax.validation.ConstraintViolation;
import javax.validation.Validator;
import java.util.Optional;
import java.util.Set;
import java.util.UUID;

@Service
public class DeleteClotheCommandHandler {

    private final IRepository repository;
    private final Validator validator;

    public DeleteClotheCommandHandler(IRepository repository, Validator validator) {
        this.repository = repository;
        this.validator = validator;
    }

    public Result handle(DeleteClotheCommand request) {
        // Validate the command
        Set<ConstraintViolation<DeleteClotheCommand>> violations = validator.validate(request);
        if (!violations.isEmpty()) {
            return new Result(false, "Invalid data", null);
        }

        // Fetch the entity from the repository
        Optional<ClotheEntity> clothe = repository.findById(request.getId());
        if (clothe.isEmpty()) {
            return new Result(false, "Clothe not found", null);
        }

        // Delete the entity
        repository.delete(clothe.get());

        return new Result(true, "Clothe deleted successfully", clothe.get().getId());
    }
}
