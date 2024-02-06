#!/bin/bash

xpra start --start-child-after-connect="wine /home/xpra-test/program/WindowsFormsApp2.exe" --bind-tcp=0.0.0.0:8085 --no-daemon -d geometry