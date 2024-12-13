from typing import TypeVar, Generic, List, Optional
from uuid import UUID
from abc import ABC, abstractmethod
from asyncio import CancelledError


class IRepository(ABC):
    @abstractmethod
    def get_by_id_async(self, id: UUID):
        """Fetch an entity by its ID."""
        pass

    @abstractmethod
    def add_async(self, data):
        """Add a new entity."""
        pass

    @abstractmethod
    def update(self, data):
        """Update an entity."""
        pass

    @abstractmethod
    def delete(self, entity):
        """Delete an entity."""
        pass

    @abstractmethod
    def save_changes_async(self):
        """Commit changes."""
        pass
