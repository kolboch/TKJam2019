using System;
using UnityEngine;

public class ArenaController : MonoBehaviour
{
    public Transform playersContainer;
    public Transform player1Start;
    public Transform player2Start;
    public int PROGRESS_MAX = 500;
    public int PROGRESS_MIN = -500;
    public float MAX_DELTA = 0.001f;

    [SerializeField] private int progressValue = 0;
    private float progressNormalize;
    private Vector3 midStartPoint;


    private void Start()
    {
        midStartPoint = (player1Start.position + player2Start.position) / 2;
        progressNormalize = Math.Abs(PROGRESS_MIN) + Math.Abs(PROGRESS_MAX);
    }

    void Update()
    {
        updatePlayersPosition();
    }

    /**
     * value between PROGRESS_MIN and PROGRESS_MAX
     */
    public void setProgressValue()
    {
    }

    public void updatePlayersPosition()
    {
        Vector3 playersDirectionVector = player2Start.position - player1Start.position;
        float normalizedProgress = progressValue / progressNormalize;
        Vector3 targetPosition = midStartPoint + playersDirectionVector * normalizedProgress;
        targetPosition.y = playersContainer.position.y;
        targetPosition.x = playersContainer.position.x;
        playersContainer.position = Vector3.MoveTowards(
            playersContainer.position,
            targetPosition,
            MAX_DELTA);
    }
}