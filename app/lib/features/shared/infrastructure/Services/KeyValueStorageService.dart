abstract class Keyvaluestorageservice {
  Future<void> setKeyValue<T>(String key, T value);
  Future<T>? getValue<T>(String key);
  Future<bool> delete(String key);
}
