import 'package:flutter/material.dart';

class Register extends StatelessWidget {
  const Register({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        const Center(
            child: Text(
          'Regitro Usuario',
          style: TextStyle(fontSize: 30, fontWeight: FontWeight.bold),
        )),
        const SizedBox(
          height: 40,
        ),
        const TextField(
          decoration: InputDecoration(
            border: OutlineInputBorder(),
            hintText: 'Ingresa tu Correo',
          ),
        ),
        const SizedBox(height: 10),
        const TextField(
          decoration: InputDecoration(
            border: OutlineInputBorder(),
            hintText: 'Ingresa tu Correo',
          ),
        ),
        const SizedBox(
          height: 10,
        ),
        const TextField(
          decoration: InputDecoration(
            border: OutlineInputBorder(),
            hintText: 'Ingresa tu contraseña',
          ),
        ),
        const SizedBox(height: 10),
        const ElevatedButton(
          onPressed: null,
          child: Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Icon(Icons.check),
              SizedBox(width: 10),
              Text('Registrar'),
            ],
          ),
        ),
        const SizedBox(height: 10),
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
          children: [
            IconButton(
                onPressed: () {},
                icon: const Icon(Icons.arrow_back_ios_rounded))
          ],
        ),
      ],
    ));
  }
}
