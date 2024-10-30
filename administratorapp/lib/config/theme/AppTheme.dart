// ignore_for_file: file_names

import 'package:flutter/material.dart';

const Color _customColor = Color(0xFFE31952);
const List<Color> _colorthemes = [
  _customColor,
  Colors.blueGrey,
  Colors.yellowAccent,
  Colors.lime,
  Colors.purple
];

class AppTheme {
  int chosecolor;

  AppTheme({this.chosecolor = 0})
      : assert(chosecolor >= 0 && chosecolor < _colorthemes.length - 1);

  ThemeData theme() {
    return ThemeData(
        colorSchemeSeed: _colorthemes[chosecolor],
        useMaterial3: true,
        brightness: Brightness.dark);
  }
}
