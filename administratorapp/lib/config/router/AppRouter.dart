import 'package:go_router/go_router.dart';
import 'package:administratorapp/features/Auth/presentation/Screens/Screens.dart';

final appRouter = GoRouter(routes: [
  GoRoute(
    path: '/',
    name: Login.name,
    builder: (context, state) => const Login(),
  ),
  GoRoute(
    path: '/register',
    name: Register.name,
    builder: (context, state) => const Register(),
  ),
  GoRoute(
    path: '/productos',
    name: Listproductos.name,
    builder: (context, state) => const Listproductos(),
  )
]);
