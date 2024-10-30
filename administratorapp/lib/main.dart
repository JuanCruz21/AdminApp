import 'package:administratorapp/config/theme/AppTheme.dart';
import 'package:administratorapp/presentation/Screens/Auth/Login.dart';
import 'package:administratorapp/presentation/Screens/Auth/Register.dart';
import 'package:administratorapp/presentation/Screens/Products/DetailProducts.dart';
import 'package:administratorapp/presentation/Screens/Products/ListProductos.dart';
import 'package:flutter/material.dart';

void main() => runApp(const MyApp());

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
        debugShowCheckedModeBanner: false,
        theme: AppTheme(chosecolor: 1).theme(),
        title: 'Material App',
        home: const Detailproducts());
  }
}
