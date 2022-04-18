function [p, q, Jx, Jy, x_approx, y_approx] = get_optimal_p(Jx_func, Jy_func, x, y, t, draw_plots)

if (nargin == 5)
   draw_plots = false; 
end

% Szukanie początkowych wartości dla p1 i p2
dt = t(2) - t(1);
p = get_init_p(Jx_func, x, y, dt);
q = get_init_p(Jy_func, x, y, dt);


% optymalizacja
[p]=fmincon(@(w) Jx_func(w(1), w(2), x, y, dt), ...
            p, [], []);
[q]=fmincon(@(w) Jy_func(w(1), w(2), x, y, dt), ...
            q, [], []);

[Jx, x_approx] = (Jx_func(p(1), p(2), x, y, dt));
[Jy, y_approx] = (Jy_func(q(1), q(2), x, y, dt));

if (draw_plots)
    hold on
    subplot(2, 1, 1);
    plot(t, x, 'b', t, x_approx, 'r');

    subplot(2, 1, 2);
    plot(t, y, 'b', t, y_approx, 'r');
    hold off
end
end

