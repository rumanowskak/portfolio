function [Jx, x_approx] = calculate_Jx_ab(p1, p2, x_real, y_real, dt)
% p1, p2 parametry funkcji
% f
% x_init - wartość początkowa x
% y - wektor wartości dokładnych y

N = length(y_real);
x_approx = zeros(N, 1);
x_approx(1) = x_real(1);
f = @(x, y) p1*x - p2*x*y;

% ponieważ funkcja wymaga x_n-3 to x_2 i x_3 możemy wyznacznyć metodą
% Eulera
x_approx(2) = x_approx(1)+ f(x_approx(1), y_real(1))*dt; 
x_approx(3) = x_approx(2)+ f(x_approx(2), y_real(2))*dt; 

for i = 4:N
   x_approx(i) = x_approx(i-1) + 1/12*...
       (23*f(x_approx(i-1), y_real(i-1))-...
       16*f(x_approx(i-2), y_real(i-2))+...
       5*f(x_approx(i-3), y_real(i-3)))*dt;
end

diff = abs(x_real - x_approx);
Jx = sum(diff(2:end));

end

