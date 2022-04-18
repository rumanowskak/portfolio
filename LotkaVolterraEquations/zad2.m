%% Wczytanie danych
data = readtable('dane66.csv');
t = table2array(data(:,1));
x = table2array(data(:,2));
y = table2array(data(:,3));
dt = t(2)- t(1);

%% Szukanie paremtrów
Jx_func = @calculate_Jx_four;
Jy_func = @calculate_Jy_four;

[p, q, Jx, Jy, x_approx, y_approx] = ... 
    get_optimal_p(Jx_func, Jy_func, x, y, t, false);

p = [p, q];
% disp(p);
% calculate_J(p, x, y, t)

N = 2000;
[p,fval] = fmincon(@(p) ...
    calculate_J(p, x, y, t, N), p);

% disp(p);
% [Jx, x_approx] = Jx_func(p(1), p(2), x, y, dt);
% [Jy, y_approx] = Jy_func(p(3), p(4), x, y, dt);

% hold on
% subplot(2, 1, 1);
% plot(t, x, 'b', t, x_approx, 'r');
% 
% subplot(2, 1, 2);
% plot(t, y, 'b', t, y_approx, 'r');
% hold off

%% Przewidywanie
M = 2000;
dt = 1/N;
approx = calculate_approx(p, x, y, M, dt);
hold on
subplot(2, 1, 1);
plot(t, x, 'b', linspace(0, dt*M, M), approx(1, :), 'r');

subplot(2, 1, 2);
plot(t, y, 'b', linspace(0, dt*M, M), approx(2, :), 'r');
hold off



