import 'package:app/features/shared/infrastructure/Services/KeyValueStorageService.dart';
import 'package:shared_preferences/shared_preferences.dart';

class Keyvaluestorageserviceimpl extends Keyvaluestorageservice {
  Future<SharedPreferences> getSharedPreferences() async {
    final SharedPreferences sharedPreferences =
        await SharedPreferences.getInstance();
    return sharedPreferences;
  }

  @override
  Future<bool> delete(String key) async {
    final prefs = await getSharedPreferences();
    return await prefs.remove(key);
  }

  @override
  Future<T>? getValue<T>(String key) {
    final prefs = getSharedPreferences();
    if (T == String) {
      return prefs.then((prefs) => prefs.getString(key) as T);
    } else if (T == int) {
      return prefs.then((prefs) => prefs.getInt(key) as T);
    } else if (T == bool) {
      return prefs.then((prefs) => prefs.getBool(key) as T);
    } else if (T == double) {
      return prefs.then((prefs) => prefs.getDouble(key) as T);
    } else if (T == List<String>) {
      return prefs.then((prefs) => prefs.getStringList(key) as T);
    } else {
      throw Exception('Unsupported type for getValue');
    }
  }

  @override
  Future<void> setKeyValue<T>(String key, T value) async {
    final prefs = await getSharedPreferences();
    if (value is String) {
      await prefs.setString(key, value);
    } else if (value is int) {
      await prefs.setInt(key, value);
    } else if (value is bool) {
      await prefs.setBool(key, value);
    } else if (value is double) {
      await prefs.setDouble(key, value);
    } else if (value is List<String>) {
      await prefs.setStringList(key, value);
    } else {
      throw Exception('Unsupported type for setKeyValue');
    }
  }
}
