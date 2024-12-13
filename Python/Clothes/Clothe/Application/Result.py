
class Result:
    def __init__(self, success: bool, message: str, data=None):
        self.success = success
        self.message = message
        self.data = data

    def __repr__(self):
        return f"Result(success={self.success}, message={self.message}, data={self.data})"
