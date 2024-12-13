import unittest
from parameterized import parameterized

from Clothe.Application.CreateClothe.ClotheSizeCalculation import ClotheSizeCalculation


class TestClotheSizeCalculation(unittest.TestCase):
    def setUp(self):
        self.clothe_size_calculation = ClotheSizeCalculation()

    @parameterized.expand([
        (20, 10, "S"),
        (100, 80, "L"),
        (50, 40, "M"),
        (130, 110, "XXL"),
    ])
    def test_calculate_should_be_ok(self, height, width, expected_result):
        result = self.clothe_size_calculation.calculate(height, width)
        self.assertEqual(result, expected_result)

    def test_calculate_should_throw_exception(self):
        with self.assertRaises(ValueError):
            self.clothe_size_calculation.calculate(0, -1)


# To run the tests if this script is executed directly
if __name__ == "__main__":
    unittest.main()
