import os, sys, shutil, stat, time

input_location = None
output_location = None
pool_name = None

i = 0
while i < len(sys.argv):
    if sys.argv[i] == "-i":
        if i + 1 == len(sys.argv):
            print("-i requires argument")
            exit(1)
        
        input_location = sys.argv[i + 1]
        i = i + 2
        continue

    if sys.argv[i] == "-o":
        if i + 1 == len(sys.argv):
            print("-o requires argument")
            exit(1)
        
        output_location = sys.argv[i + 1]
        i = i + 2
        continue

    if sys.argv[i] == "-p":
        if i + 1 == len(sys.argv):
            print("-p requires argument")
            exit(1)
        
        pool_name = sys.argv[i + 1]
        i = i + 2
        continue

    i = i + 1

##################################################################

def clearDirectory(path):
    if not os.path.exists(path):
        raise Exception("Directory not found: {}".format(path))
    
    errors = 0

    for name in os.listdir(path):
        subpath = os.path.join(path, name)
        if os.path.isdir(subpath):
            if clearDirectory(subpath):
                for i in range(0, 20):
                    try:
                        os.rmdir(subpath)
                        break
                    except:
                        time.sleep(0.1)
        else:
            #print(subpath)
            try:
                os.chmod(subpath, stat.S_IWRITE)
                os.unlink(subpath)
            except:
                errors = errors + 1
    
    return errors == 0

##################################################################

if not input_location or not os.path.exists(input_location):
    print("Input folder not found: {}".format(input_location))
    exit(1)

if not output_location or not os.path.exists(output_location):
    print("Output folder not found: {}".format(output_location))
    exit(1)

appcmd_path = os.path.join(os.environ["windir"], "system32\\inetsrv")

os.environ["PATH"] = "{};{}".format(os.environ["PATH"], appcmd_path)

# Stop the app pool
code = os.system("appcmd.exe stop apppool /apppool.name:\"{}\"".format(pool_name))
if code != 0:
    print("Failed to stop application pool '{}' (code: {})".format(pool_name, code))

# Clear the output location folder
print("Clearing output location")
clearDirectory(output_location)

# Copy new files from input to output
print("Publishing new files")
shutil.copytree(input_location, output_location, dirs_exist_ok=True)

# Start the pool
code = os.system("appcmd.exe start apppool /apppool.name:\"{}\"".format(pool_name))
if code != 0:
    print("Failed to start application pool '{}' (code: {})".format(pool_name, code))
    exit(code)