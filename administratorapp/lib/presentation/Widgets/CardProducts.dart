import 'package:flutter/material.dart';

class CardProducts extends StatelessWidget {
  final int id;
  final String nombre;
  final String descripcion;
  final int stock;
  final double precio;
  const CardProducts(
      {super.key,
      required,
      required this.id,
      required this.nombre,
      required this.descripcion,
      required this.stock,
      required this.precio});

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.only(top: 10),
      child: Row(
        children: [
          const SizedBox(width: 10),
          Expanded(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  'Product Name: $nombre',
                  style: const TextStyle(
                    fontSize: 18,
                    fontWeight: FontWeight.bold,
                  ),
                ),
                const SizedBox(height: 5),
                Text(
                  'Product Description: $descripcion',
                  style: const TextStyle(
                    fontSize: 16,
                    color: Colors.grey,
                  ),
                ),
                const SizedBox(height: 5),
                Text(
                  'Stock ${stock.toString()}',
                  style: const TextStyle(
                    fontSize: 16,
                    color: Colors.grey,
                  ),
                ),
                const SizedBox(height: 5),
                const Text(
                  '\$99.99',
                  style: TextStyle(
                    fontSize: 18,
                    fontWeight: FontWeight.bold,
                    color: Colors.green,
                  ),
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
