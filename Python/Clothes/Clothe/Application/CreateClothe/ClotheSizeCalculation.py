class ClotheSizeCalculation:
    def __init__(self):
        pass

    def calculate(self, height: int, width: int) -> str:
        if height <= 0 or width <= 0:
            raise ValueError("Invalid height, width")

        if height <= 40 and width <= 20:
            return "S"

        if 80 <= height <= 120 and 60 <= width <= 100:
            return "L"

        if 40 <= height < 80 and 20 <= width < 60:
            return "M"

        return "XXL"



