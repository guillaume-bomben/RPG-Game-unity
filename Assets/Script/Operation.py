import math

level = int(input("Enter the level: "))
baseStat = int(input("Enter the base stat: "))


stat = (( ( level / 100 ) * baseStat ) + level + ( ( math.sqrt(baseStat) + level ) / 2.5 ) ) // 1
print(f"La Statistique au niveau {level} est de {stat} ")