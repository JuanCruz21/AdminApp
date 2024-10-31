class ConnectionTimeout implements Exception {}

class InvalidToken implements Exception {}

class WrongCredentials implements Exception {
  final String message;
  // final int errorCode;
  WrongCredentials(this.message);
}

class CustomError implements Exception {
  final String message;
  // final int errorCode;
  CustomError(this.message);
}
