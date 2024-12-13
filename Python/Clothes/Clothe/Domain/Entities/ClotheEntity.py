from Clothe.Domain.Entities.BaseEntity import BaseEntity


class ClotheEntity(BaseEntity):
    def __init__(self, name: str, fabric: str, year: int, size: str, color: str):
        super().__init__()
        self._name = name
        self._fabric = fabric
        self._year = year
        self._size = size
        self._color = color

    @property
    def name(self) -> str:
        return self._name

    @property
    def fabric(self) -> str:
        return self._fabric

    @property
    def year(self) -> int:
        return self._year

    @property
    def size(self) -> str:
        return self._size

    @property
    def color(self) -> str:
        return self._color
