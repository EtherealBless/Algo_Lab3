using Lab3.Menus;
IMenu menu;
#if DEBUG
menu = new DebugMenu();
#else
menu = new Menu();
#endif
menu.RunMenu();
