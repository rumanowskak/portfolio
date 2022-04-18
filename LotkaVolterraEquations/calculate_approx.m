function [approx] = calculate_approx(p, x_real, y_real, N, dt)
p1 = p(1);
p2 = p(2);
p3 = p(3);
p4 = p(4);

approx = zeros(2, N);
approx(:, 1) = [x_real(1); y_real(1)];

for i = 2:N
    A = [p1, -p2*approx(1,i-1); p3*approx(2,i-1), -p4];
    approx(:,i) = approx(:,i-1) + A*approx(:,i-1)*dt;
end
end

