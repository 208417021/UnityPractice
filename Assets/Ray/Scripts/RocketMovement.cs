using UnityEngine;
using UnityEngine.SceneManagement;
// using CollsionHandler;
public class RocketMovement : MonoBehaviour
{
    private float fuelMount = 100f;
    [SerializeField] float fuelMax = 100f;
    [SerializeField] float fuelRecovery = 10f;
    [SerializeField] float fuelConsume = 35f;
    [SerializeField] float moveSpeed = 800f;
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] ParticleSystem mainEngine;
    [SerializeField] ParticleSystem leftThruster;
    [SerializeField] ParticleSystem rightThruster;
    [SerializeField] TMPro.TextMeshProUGUI fuel;
    // [SerializeField] float audioVolume = 1f;
    // Start is called before the first frame update
    Rigidbody rb;
    // AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // fuel = GetComponent<TextMesh>();
        fuel.text = "Finally";
        fuelMount = fuelMax;
        // audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        if(transform.position.y < 0)
        {
            GetComponent<RocketMovement>().enabled = false; // dangerous for initalization
            Invoke("DelaySequence", 1);
        }
        // audioSource.volume = audioVolume;
    }

    void DelaySequence()
    {
        CollsionHandler.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void ProcessInput()
    {
        fuel.text = "Fuel: " + Mathf.Round(fuelMount);
        if(fuelMount < fuelMax) fuelMount += fuelRecovery * Time.deltaTime;
        if(fuelMount <= 0) return;
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //transform.Translate(0, moveSpeed * Time.deltaTime, 0);
            rb.AddRelativeForce(Vector3.up * moveSpeed * Time.deltaTime); //move to the direction, Vector3.up = (0,1,0)
            fuelMount -= fuelConsume * Time.deltaTime;
            //remember the mass of game object to use AddRelativeForce()
            //Debug.Log("SPACE");
            // if(!audioSource.isPlaying)
            //     audioSource.Play();
            if(!mainEngine.isEmitting)
                mainEngine.Play();
        }
        else
            mainEngine.Stop();

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //transform.Rotate(-1, 0, 0);
            Rotation(rotationSpeed);
            if (!leftThruster.isEmitting)
                leftThruster.Play();
            //Debug.Log(GetComponent<Transform>().rotation.x);
        }
        else
            leftThruster.Stop();

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Rotation(-rotationSpeed);
            if (!rightThruster.isEmitting)
                rightThruster.Play();
            //Debug.Log(GetComponent<Transform>().rotation.x);
        }
        else
            rightThruster.Stop();
    }

    private void Rotation(float speed)
    {
        rb.freezeRotation = true; //freezing rotation if hit obstacle
        transform.Rotate(Vector3.back * speed * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
