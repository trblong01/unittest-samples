import uuid
from datetime import datetime


class BaseEntity:
    def __init__(self):
        self.id = uuid.uuid4()
        self.created_at = datetime.now()
        self.updated_at = datetime.now()
        self.created_by = "System"
        self.updated_by = None
