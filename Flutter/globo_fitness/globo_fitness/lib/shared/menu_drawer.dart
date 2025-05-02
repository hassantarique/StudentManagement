import 'package:flutter/material.dart';
import 'package:globo_fitness/screens/sessions_screen.dart';
import '../screens/weather_screen.dart';
import '../screens/bmi_screen.dart';
import '../screens/intro_screen.dart';

class MenuDrawer extends StatelessWidget {
  const MenuDrawer({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: ListView(
        children: buildMenuItems(context),
      ),
    );
  }

  List<Widget> buildMenuItems(BuildContext context) {
    final List<String> menuTitles = [
      'Home',
      'BMI Calculator',
      'Weather',
      'Training',
    ];
    List<Widget> menuItems = [];

    menuItems.add(
      const DrawerHeader(
        decoration: BoxDecoration(color: Colors.blueGrey),
        child: Text(
          'Globo Fitness',
          style: TextStyle(color: Colors.white, fontSize: 28),
        ),
      ),
    );

    for (var element in menuTitles) {
      Widget screen = const IntroScreen(); // Default fallback
      switch (element) {
        case 'Home':
          screen = const IntroScreen();
          break;
        case 'BMI Calculator':
          screen = const BmiScreen();
          break;
        case 'Weather':
          screen = const WeatherScreen();
          break;
        case 'Training':
          screen = const SessionsScreen();
          break;
      }

      menuItems.add(
        ListTile(
          title: Text(element, style: const TextStyle(fontSize: 18)),
          onTap: () {
            Navigator.of(context).pop(); // Close drawer
            Navigator.of(context).pushAndRemoveUntil(
              MaterialPageRoute(builder: (context) => screen),
              (route) => false, // Clears the stack
            );
          },
        ),
      );
    }

    return menuItems;
  }
}
