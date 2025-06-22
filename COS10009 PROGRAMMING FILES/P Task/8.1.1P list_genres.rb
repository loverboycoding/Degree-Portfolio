# put the genre names array here:
$genre_names = ['Pop', 'Classic', 'Jazz', 'Rock']

def main
  $genre_names.each_with_index do |genre, index|
    puts "#{index + 1} #{genre}"
  end
end

main()

