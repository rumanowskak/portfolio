function [Jy, y_approx] = calculate_Jy_euler(p3, p4, x_real, y_real, dt)

N = length(y_real);
y_approx = zeros(N, 1);
y_approx(1) = y_real(1);
f = @(x, y) p3*y*x - p4*y;

for i = 2:N
   y_approx(i)=y_approx(i-1)+ f(x_real(i-1), y_approx(i-1))*dt; 
end

diff = abs(y_real - y_approx);
Jy = sum(diff(2:end));

end

