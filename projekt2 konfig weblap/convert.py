import random
colors = ["turq","blue","green","yellow","violet","pink","red","orange",]
with open("data.txt", "r") as file_old, open("newdata.txt", "w") as new_file:
        for i in file_old:
            line=i.strip()+';'+colors[random.randint(0,len(colors)-1)]+".png\n"
            new_file.write(line)