import 'package:app/features/auth/domain/domain.dart';
import 'package:app/features/auth/infraestructure/errors/AuthErrors.dart';
import 'package:app/features/auth/infraestructure/infraestructure.dart';
import 'package:app/features/shared/infrastructure/Services/KeyValueStorageService.dart';
import 'package:app/features/shared/infrastructure/Services/keyValueStorageServiceImpl.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

final authProvider = StateNotifierProvider<AuthNotifier, AuthState>((ref) {
  final authRepository = Authrepositoryimpl();
  final keyValueStorageserviceImpl = Keyvaluestorageserviceimpl();

  return AuthNotifier(
      authRepository: authRepository,
      keyvaluestorageservice: keyValueStorageserviceImpl);
});

class AuthNotifier extends StateNotifier<AuthState> {
  final Authrepository authRepository;
  final Keyvaluestorageservice keyvaluestorageservice;
  AuthNotifier(
      {required this.authRepository, required this.keyvaluestorageservice})
      : super(AuthState());

  Future<void> loginUser(String email, String password) async {
    await Future.delayed(const Duration(milliseconds: 500));
    try {
      final user = await authRepository.login(email, password);
      print(user);
      _setLoggedUser(user);
    } on WrongCredentials {
      logout('Credenciales incorrectas');
    } on ConnectionTimeout {
      logout('Revisar conexión a internet');
    } catch (e) {
      logout('Error no controlado ${e}');
    }

    // final user = await authRepository.login(email, password);
    // state =state.copyWith(user: user, authStatus: AuthStatus.authenticated)
  }

  void registerUser(String email, String password) async {}

  void checkAuthStatus() async {}

  void _setLoggedUser(Usuario user) async {
    // TODO: necesito guardar el token físicamente
    await keyvaluestorageservice.setKeyValue('token', user.token);
    state = state.copyWith(
      user: user,
      authStatus: AuthStatus.authenticated,
    );
  }

  Future<void> logout([String? errorMessage]) async {
    // TODO: limpiar token
    await keyvaluestorageservice.delete('token');
    state = state.copyWith(
        authStatus: AuthStatus.notAuthenticated,
        user: null,
        errorMessage: errorMessage);
  }
}

enum AuthStatus { checking, authenticated, notAuthenticated }

class AuthState {
  final AuthStatus authStatus;
  final Usuario? user;
  final String errorMessage;

  AuthState(
      {this.authStatus = AuthStatus.checking,
      this.user,
      this.errorMessage = ''});

  AuthState copyWith({
    AuthStatus? authStatus,
    Usuario? user,
    String? errorMessage,
  }) =>
      AuthState(
          authStatus: authStatus ?? this.authStatus,
          user: user ?? this.user,
          errorMessage: errorMessage ?? this.errorMessage);
}
