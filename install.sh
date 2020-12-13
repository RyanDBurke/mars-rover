#!/bin/bash

# Define some colors.
LIGHT_PURPLE='\033[1;35m'
LIGHT_CYAN='\033[1;36m'
ORIG_COLOR='\033[0m'

P=${LIGHT_PURPLE}
C=${LIGHT_CYAN}
O=${ORIG_COLOR}

# install make and mono (c# compiler)
echo -e "\n${C}Installing ${P}Mono${C} & ${P}Make${C} with apt-get..${O}\n"
sudo apt-get update
sudo apt-get install build-essential
sudo apt install mono-complete
echo -e "\n${C}Scripts done.${O}"