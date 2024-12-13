from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy.future import select
from sqlalchemy.exc import NoResultFound
from typing import TypeVar, Generic, List, Optional
from uuid import UUID

from Clothe.Domain.Entities.ClotheEntity import ClotheEntity
from Clothe.Domain.Repositories.IRepository import IRepository


class ClotheRepository(IRepository):
    def __init__(self, session: AsyncSession):
        self._session = session

    def add_async(self, entity):
        """Adds a new entity to the session."""
        self._session.add(entity)

    def delete(self, entity):
        """Removes an entity from the session."""
        self._session.delete(entity)

    def get_by_id_async(self, id: UUID):
        """Fetches an entity by its ID."""
        try:
            result = self._session.execute(select(ClotheEntity).filter_by(id=id))
            return result.scalar_one_or_none()
        except NoResultFound:
            return None

    def save_changes_async(self):
        """Commits the transaction."""
        self._session.commit()

    def update(self, entity):
        """Marks an entity as updated."""
        self._session.add(entity)  # In SQLAlchemy, 'add' includes updates.
