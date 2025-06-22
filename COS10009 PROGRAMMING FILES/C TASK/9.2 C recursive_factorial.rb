# Recursive Factorial

# Complete the following
def factorial(n)
  return 1 if n == 0
  n * factorial(n - 1)
end

def main
  if ARGV.length != 1 || ARGV[0].to_i.to_s != ARGV[0] || ARGV[0].to_i < 0
    puts("Incorrect argument - need a single argument with a value of 0 or more.\n")
  else
    puts factorial(ARGV[0].to_i)
  end
end

main

