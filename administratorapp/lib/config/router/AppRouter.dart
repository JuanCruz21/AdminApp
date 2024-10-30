import 'package:administratorapp/presentation/Screens/Auth/Login.dart';
import 'package:go_router/go_router.dart';

final appRouter = GoRouter(routes: [
  GoRoute(
    path: '/',
    name: Login.name,
    builder: (context, state) => const Login(),
  ),
]);
