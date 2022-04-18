function [Jx, x_approx] = calculate_Jx_euler(p1, p2, x_real, y_real, dt)
% p1, p2 parametry funkcji
% f
% x_init - wartość początkowa x
% y - wektor wartości dokładnych y

N = length(y_real);
x_approx = zeros(N, 1);
x_approx(1) = x_real(1);
f = @(x, y) p1*x - p2*x*y;

for i = 2:N
   x_approx(i)=x_approx(i-1)+ f(x_approx(i-1), y_real(i-1))*dt; 
end

diff = abs(x_real - x_approx);
Jx = sum(diff(2:end));

end

