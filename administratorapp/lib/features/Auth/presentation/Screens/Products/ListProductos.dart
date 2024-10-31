import 'package:administratorapp/features/Auth/presentation/Widgets/CardProducts.dart';
import 'package:flutter/material.dart';

class Listproductos extends StatelessWidget {
  static const String name = 'listproductos';
  const Listproductos({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Listado de productos'),
      ),
      body: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Expanded(
            child: ListView.builder(
              itemCount: 9,
              itemBuilder: (BuildContext context, int index) {
                return const CardProducts(
                  id: 1,
                  nombre: 'Prueba',
                  descripcion: 'Prueba de descripcion',
                  stock: 10,
                  precio: 1000,
                );
              },
            ),
          ),
        ],
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {},
        child: const Icon(Icons.add),
      ),
    );
  }
}
