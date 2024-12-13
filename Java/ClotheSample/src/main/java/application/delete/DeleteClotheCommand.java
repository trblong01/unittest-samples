package application.delete;

import javax.validation.constraints.NotNull;

import java.util.UUID;

public class DeleteClotheCommand {

    @NotNull
    private UUID id;

    public DeleteClotheCommand() {
    }

    public DeleteClotheCommand(UUID id) {
        this.id = id;
    }

    public UUID getId() {
        return id;
    }

    public void setId(UUID id) {
        this.id = id;
    }
}
