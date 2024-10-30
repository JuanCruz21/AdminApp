import 'package:administratorapp/config/router/AppRouter.dart';
import 'package:administratorapp/config/theme/AppTheme.dart';
import 'package:flutter/material.dart';
import 'package:flutter_dotenv/flutter_dotenv.dart';

Future<void> main() async {
  await dotenv.load(fileName: ".env");
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp.router(
        debugShowCheckedModeBanner: false,
        theme: AppTheme(chosecolor: 1).theme(),
        title: 'Material App',
        routerConfig: appRouter);
  }
}
