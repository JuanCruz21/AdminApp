import 'package:flutter/material.dart';

class Login extends StatelessWidget {
  const Login({super.key});

  @override
  Widget build(BuildContext context) {
    return const Scaffold(
        body: Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Center(
            child: Text(
          'Login',
          style: TextStyle(fontSize: 30, fontWeight: FontWeight.bold),
        )),
        SizedBox(
          height: 40,
        ),
        TextField(
          decoration: InputDecoration(
            border: OutlineInputBorder(),
            hintText: 'Ingresa tu Correo',
          ),
        ),
        SizedBox(
          height: 10,
        ),
        TextField(
          decoration: InputDecoration(
            border: OutlineInputBorder(),
            hintText: 'Ingresa tu contraseña',
          ),
        ),
        SizedBox(height: 10),
        ElevatedButton(onPressed: null, child: Text('Login')),
        SizedBox(height: 10),
        Text('Forgot Password?'),
        SizedBox(height: 10),
        Text('Don\'t have an account?'),
      ],
    ));
  }
}
