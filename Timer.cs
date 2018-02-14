using System;

public class Timer
{
    private float m_interval = 0;
    private int m_loopCount = 1;
    private int m_curLoopCount = 1;
    private Action m_callback = null;
    private System.Timers.Timer m_timer;
    private bool isRunning;
    public Timer(float interval, int loopCount = 1, Action callback = null)
    {
        m_interval = interval*1000;
        m_loopCount = loopCount;       
        m_callback = callback;
        isRunning = false;
    }

    public void Start()
    {
        if (isRunning)
            Stop();
        m_timer = new System.Timers.Timer(m_interval);
        m_curLoopCount = m_loopCount;
        m_timer.Elapsed += delegate
        {                    
            if (m_callback != null)
                m_callback();
            m_curLoopCount--;
            if (m_curLoopCount <= 0)
                m_timer.Stop();
        };
        m_timer.Start();
        isRunning = true;
    }

    public void Stop()
    {
        if (m_timer != null)
        {
            m_timer.Stop();
            m_timer.Close();
            m_timer.Dispose();
        }
        isRunning = false;
    }    
}





