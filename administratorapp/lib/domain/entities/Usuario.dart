import 'package:flutter/material.dart';

class Usuario {
  final int usuarioid;
  final String email;
  final String nombre;
  final Text contrasena;

  Usuario({
    required this.usuarioid,
    required this.email,
    required this.nombre,
    required this.contrasena,
  });
}
