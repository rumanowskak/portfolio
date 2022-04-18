function [J] = calculate_J(p, x_real, y_real, t, N)

if nargin == 4
    N = 1000;
end

dt = 1 / N;

approx = calculate_approx(p, x_real, y_real, N, dt);

interp_x = interp1(linspace(0, 1, N), approx(1,:), t);
interp_y = interp1(linspace(0, 1, N), approx(2,:), t);

diff_x = abs(interp_x - x_real);
diff_y = abs(interp_y - y_real);
diff_s = diff_x + diff_y;
J = sum(diff_s(2:end), 'all');
end

