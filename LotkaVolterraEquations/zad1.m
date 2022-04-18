%% Wczytanie danych
data = readtable('dane66.csv');
t = table2array(data(:,1));
x = table2array(data(:,2));
y = table2array(data(:,3));

%% Metoda Eulera
Jx_func = @calculate_Jx_euler;
Jy_func = @calculate_Jy_euler;

[p, q, Jx, Jy, x_approx, y_approx] = ...
    get_optimal_p(Jx_func, Jy_func, x, y, t, true);
disp(p); % p1, p2
disp(q); % p3, p4

%% Metoda Adamsa-Bashforta 3-go rzędu
Jx_func = @calculate_Jx_ab;
Jy_func = @calculate_Jy_ab;

[p, q, Jx, Jy, x_approx, y_approx] = ...
    get_optimal_p(Jx_func, Jy_func, x, y, t, true);
disp(p); % p1, p2
disp(q); % p3, p4

%% Metoda Eulera (niejawna)
Jx_func = @calculate_Jx_euler_imp;
Jy_func = @calculate_Jy_euler_imp;

[p, q, Jx, Jy, x_approx, y_approx] = ...
    get_optimal_p(Jx_func, Jy_func, x, y, t, true);
disp(p); % p1, p2
disp(q); % p3, p4

%% Metoda Czwarta
Jx_func = @calculate_Jx_four;
Jy_func = @calculate_Jy_four;

[p, q, Jx, Jy, x_approx, y_approx] = ...
    get_optimal_p(Jx_func, Jy_func, x, y, t, true);
disp(p); % p1, p2
disp(q); % p3, p4
disp(Jx);
disp(Jy);