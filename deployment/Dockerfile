FROM ubuntu:22.04
ENV WINEDEBUG=fixme-all

RUN apt-get update && \
    apt-get install -y wget apt-transport-https software-properties-common ca-certificates && \
    dpkg --add-architecture i386 && \
    mkdir -pm755 /etc/apt/keyrings && \
    wget -O /etc/apt/keyrings/winehq-archive.key https://dl.winehq.org/wine-builds/winehq.key && \
    wget -NP /etc/apt/sources.list.d/ https://dl.winehq.org/wine-builds/ubuntu/dists/jammy/winehq-jammy.sources && \
    wget -O /usr/share/keyrings/xpra.asc https://xpra.org/xpra.asc && \
    wget -O /etc/apt/sources.list.d/xpra.sources https://xpra.org/repos/jammy/xpra.sources
    

RUN apt-get update && \
    apt-get install -y --install-recommends winehq-stable

RUN apt-get update && \
    apt-get install -y \
    xvfb \
    python3-pip \
    libx11-dev \
    x11-apps \
    x11-xserver-utils


RUN apt-get install -y xpra=5.0.5-r0-1 && \
    apt-get clean

RUN useradd -ms /bin/bash xpra-test

RUN wget -P /mono https://dl.winehq.org/wine/wine-mono/9.0.0/wine-mono-9.0.0-x86.msi && \
    wine msiexec /i /mono/wine-mono-9.0.0-x86.msi && \
    wineserver -w && \
    chown -R xpra-test:xpra-test /mono

COPY ./WindowsFormsApp2.exe /home/xpra-test/program/WindowsFormsApp2.exe
COPY ./run.sh /home/xpra-test/run.sh
RUN chmod +x /home/xpra-test/run.sh && \
    chown -R xpra-test:xpra-test /home/xpra-test/program \
    
USER xpra-test

RUN wine msiexec /i /mono/wine-mono-9.0.0-x86.msi && \
    wineserver -w && \
    rm -rf /mono/wine-mono-9.0.0-x86.msi
    
CMD ["/bin/bash", "/home/xpra-test/run.sh"]
