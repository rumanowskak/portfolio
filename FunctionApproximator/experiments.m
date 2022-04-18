%% Eksperment 1
f = @(x) x.^2 + x + 1;
[tab, mse] = test05(f, 2, 1, 50, true);
disp(mse);

%% Eksperyment 2
f_1 = @(x) 2*x.^3 - 3*x.^2;
plot_mse(f_1, "f_1");

f_2 = @(x) x.^8 - 5*x.^3 + 12*x.^2 + 7;
plot_mse(f_2, "f_2");

f_3 = @(x) -3*x.^15-3*x.^7+1/2*x.^3;
plot_mse(f_3, "f_3");

f_4 = @(x) x.^20 - x.^10 + x.^5 -x;
plot_mse(f_4, "f_4");
%% Eksperyment 3
show_plots = false;
f = @(x) sin(cos(2.*x)) + cos(4.*x+pi/2);
[tab, mse] = test05(f, 3, 1, 1000, show_plots);
disp(mse);
[tab, mse] = test05(f, 3, 2, 1000, show_plots);
disp(mse);
[tab, mse] = test05(f, 3, 4, 1000, show_plots);
disp(mse);
[tab, mse] = test05(f, 5, 4, 1000, show_plots);
disp(mse);
[tab, mse] = test05(f, 7, 4, 1000, show_plots);
disp(mse);
xlim([-1, 1]);

plot_mse(f, "E3");

%% Eksperyment 4
show_plots = true;
f_1 = @(x) 1./(abs(sin(x))+2);
%plot_mse(f_1, "f_1");
%[tab, mse] = test05(f_1, 20, 10, 200, show_plots);
%[tab, mse] = test05(f_1, 20, 30, 200, show_plots);

f_2 = @(x) (-2*1)/pi*atan(cot(pi*x*1.5));
%plot_mse(f_2, "f_2");
%[tab, mse] = test05(f_2, 9, 6, 200, show_plots);
%[tab, mse] = test05(f_2, 30, 30, 200, show_plots);


f_3 = @(x) sqrt(abs(sin(10*x)));
%plot_mse(f_3, "f_3");
%[tab, mse] = test05(f_3, 18, 10, 500, show_plots);
%[tab, mse] = test05(f_3, 26, 30, 500, show_plots);


f_4 = @(x) exp(abs(x)-x.^2);
%plot_mse(f_4, "f_4");
%[tab, mse] = test05(f_4, 8, 4, 200, show_plots);
%[tab, mse] = test05(f_4, 23, 30, 200, show_plots);


f_5 = @(x) abs(exp(x+1)-3*(x+1));
%plot_mse(f_5, "f_5");
%[tab, mse] = test05(f_5, 8, 5, 200, show_plots);
%[tab, mse] = test05(f_5, 22, 30, 200, show_plots);

f_6 = @(x) sin(20*x);
%plot_mse(f_6, "f_6");
%[tab, mse] = test05(f_6, 21, 15, 200, show_plots);
[tab, mse] = test05(f_6, 25, 30, 200, show_plots);

