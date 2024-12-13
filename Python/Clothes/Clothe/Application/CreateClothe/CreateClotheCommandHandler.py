from Clothe.Application.Result import Result
from Clothe.Application.CreateClothe.CreateClotheCommandValidator import CreateClotheCommandValidator
from Clothe.Domain.Entities.ClotheEntity import ClotheEntity
from Clothe.Domain.Repositories import IRepository
from Clothe.Infra.Repositories import ClotheRepository


class CreateClotheCommandHandler:
    def __init__(self, validator: CreateClotheCommandValidator, repository: ClotheRepository):
        self._validator = validator
        self._repository = repository

    def handle(self, request):
        validation_errors = self._validator.validate(request)

        if validation_errors:
            return Result(success=False, message="Invalid data", data=validation_errors)

        clothe = ClotheEntity(request.name, request.model, request.year, request.size, request.color)
        self._repository.add_async(clothe)
        self._repository.save_changes_async()

        return Result(success=True, message="Clothe created successfully", data=clothe.id)
