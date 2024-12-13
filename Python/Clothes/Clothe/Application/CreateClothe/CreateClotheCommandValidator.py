class CreateClotheCommandValidator:
    def validate(self, request):
        # Simulating the validation (e.g., using pydantic or custom validation logic)
        errors = []
        if request is None or len(request.name) == 0 or len(request.model) == 0 or len(request.size) == 0 or len(request.color) == 0:
            errors.append("Fields must not be empty.")
        if request.year < 2024:
            errors.append("Year must be greater than or equal to 2024.")
        return errors