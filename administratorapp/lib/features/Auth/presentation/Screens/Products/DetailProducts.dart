import 'package:administratorapp/features/Auth/presentation/Widgets/CardMovements.dart';
import 'package:administratorapp/features/Auth/presentation/Widgets/CardProducts.dart';
import 'package:flutter/material.dart';

class Detailproducts extends StatelessWidget {
  const Detailproducts({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Detalle de producto'),
      ),
      body: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          const CardProducts(
            id: 1,
            nombre: 'Prueba',
            descripcion: 'Prueba de descripcion',
            stock: 10,
            precio: 1000,
          ),
          const Text(
            'Movimientos',
            style: TextStyle(
              fontSize: 20,
              fontWeight: FontWeight.bold,
            ),
          ),
          Expanded(
            child: ListView.builder(
              itemCount: 9,
              itemBuilder: (BuildContext context, int index) {
                return const MovementsCard();
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
