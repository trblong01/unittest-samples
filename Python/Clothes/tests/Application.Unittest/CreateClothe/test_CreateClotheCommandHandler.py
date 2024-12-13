import unittest
from unittest.mock import AsyncMock, MagicMock
from parameterized import parameterized
import pytest
import coverage
from Clothe.Application.CreateClothe.CreateClotheCommand import CreateClotheCommand

from Clothe.Application.CreateClothe.CreateClotheCommandHandler import CreateClotheCommandHandler
from Clothe.Application.CreateClothe.CreateClotheCommandValidator import CreateClotheCommandValidator
from Clothe.Domain.Repositories.IRepository import IRepository
import asyncio


class TestCreateClotheCommandHandler(unittest.TestCase):

    def setUp(self):
        self._validator = CreateClotheCommandValidator()
        self._repository_mock = MagicMock(IRepository)  # Mocking the repository
        # self._repository_mock.add_async = AsyncMock()  # Mocking async method
        self._handler = CreateClotheCommandHandler(self._validator, self._repository_mock)

    def test_handle_valid_request_should_return_success_result(self):
        # Arrange
        request = CreateClotheCommand("Test", "Cotton", 2024, "XXL", "Color")

        # Act
        result = self._handler.handle(request)

        # Assert
        self.assertTrue(result.success)
        self.assertEqual(result.message, "Clothe created successfully")

    @parameterized.expand([
        ("", "Cotton", 2022, "S", "White"),
        ("Test", "", 2022, "M", "Black"),
        ("Test", "Cotton", 2024, "L", ""),
        ("Test", "Jean", 2022, "", "Blue"),
        ("Test", "Jean", 2022, "", "Red")
    ])
    def test_handle_invalid_request_should_return_failure_result(self, name, model, year, size, color):
        # Arrange
        request = CreateClotheCommand(name, model, year, size, color)

        #  Act
        result = self._handler.handle(request)

        # # Assert
        self.assertFalse(result.success)
        self.assertEqual(result.message, "Invalid data")


if __name__ == '__main__':
    unittest.main()
