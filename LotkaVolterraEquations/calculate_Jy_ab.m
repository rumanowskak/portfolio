function [Jy, y_approx] = calculate_Jy_ab(p3, p4, x_real, y_real, dt)
N = length(y_real);
y_approx = zeros(N, 1);
y_approx(1) = y_real(1);
f = @(x, y) p3*x*y - p4*y;

% ponieważ funkcja wymaga x_n-3 to x_2 i x_3 możemy wyznacznyć metodą
% Eulera
y_approx(2) = y_approx(1)+ f(x_real(1), y_approx(1))*dt; 
y_approx(3) = y_approx(2)+ f(x_real(2), y_approx(2))*dt;

for i = 4:N
   y_approx(i) = y_approx(i-1) + 1/12*...
       (23*f(x_real(i-1), y_approx(i-1))-...
       16*f(x_real(i-2), y_approx(i-2))+...
       5*f(x_real(i-3), y_approx(i-3)))*dt;
end

diff = abs(y_real - y_approx);
Jy = sum(diff(2:end));

end

